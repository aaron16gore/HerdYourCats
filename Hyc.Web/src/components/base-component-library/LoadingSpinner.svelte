<script lang="ts">
    export let iconSize: number = 1;

    let className: string = "";

    $: className = `fa-solid fa-spin fa-spinner fa-${iconSize}x`;
</script>

<div class="icon-container">
    <i class={className}></i>
</div>

<style lang="css">
</style>