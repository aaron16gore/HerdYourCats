<script lang="ts">
    export let length: number | undefined = undefined; //Override width in rem;
    export let height: number | undefined = undefined; //Override height in rem;
    export let disabled: boolean = false; // Button is enabled by default
    export let action: () => void = () => alert(`Button has not had functionaility implemented at this time. Thanks for your patience while we work on this.`);

    function handleClick() {
        if (!disabled) {
            action();
        }
    }
</script>

<button
    on:click={handleClick}
    {disabled}
    style={`--length: ${length}; --height: ${height};`}
>
    <slot />
</button>

<style>
    button {
        width: var(--length, 2rem);
        height: var(--height, 1rem);
        background-color: var(--hys-info-color-6);
        border: none;
        border-radius: 1rem;
        color: var(--hys-white-color);
        font-weight: bold;
        cursor: pointer;
        box-shadow: 0 0.1rem 0.2rem rgba(0, 0, 0, 0.1);
        transition: all 0.3s ease;
        outline: none;
        padding: 0.5rem;
    }

    button:hover,
    button:focus {
        background-image: linear-gradient(to right, #8a0eeb 0%, #3a8dfd 100%);
        box-shadow: 0 5px 15px rgba(0, 0, 0, 0.2);
    }

    button:disabled {
        background-image: linear-gradient(to right, #ccc 0%, #ddd 100%);
        cursor: not-allowed;
        box-shadow: none;
    }
</style>
